using INTEXII_App.Areas.Identity.Data;
using INTEXII_App.Areas.Identity.Pages.Account;
using INTEXII_App.Models.AdminModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INTEXII_App.Controllers
{
    //Administration controller handles authentication, authorization, and access control
    [Authorize(Roles = "Admin")]  //Only admins can access the functionility of this controller
    public class AdministrationController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager; 

        public AdministrationController(RoleManager<IdentityRole> roleManager, 
                                        UserManager<ApplicationUser> userManager,
                                        SignInManager<ApplicationUser> signInManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        //Returns the create role view
        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        //Creates a role in the system that connects to ASPNETROLES table in LoginUsers database
        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRole model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole //create a new identity role instance
                {
                    Name = model.RoleName
                };

                IdentityResult result = await roleManager.CreateAsync(identityRole);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListRoles", "administration");
                }

                foreach(IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }


            return View(model);
        }

        //Display list of roles in the LIstRolesView
        [HttpGet]
        public IActionResult ListRoles()
        {
            var roles = roleManager.Roles;
            return View(roles);
        }

        //View that allows for editing roles to the system
        [HttpGet]
        public async Task<IActionResult> EditRole(string id)
        {
            //Pass id associated with role
            var role = await roleManager.FindByIdAsync(id);

            if(role == null)
            {
                ViewBag.ErrorMessage = $"Role with ID = {id} cannot be found";
                return View("NotFound");
            }

            //Create instance of EditRole model
            var model = new EditRole
            {
                Id = role.Id,
                RoleName = role.Name
            };

            //Loop to display all users associated with the role selected
            foreach(var user in userManager.Users)
            {
                if (await userManager.IsInRoleAsync(user, role.Name))
                {
                    model.Users.Add(user.UserName);
                }
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditRole(EditRole model)
        {
            //Set role to the original role name
            var role = await roleManager.FindByIdAsync(model.Id);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with ID = {model.Id} cannot be found";
                return View("NotFound");
            }
            else
            {
                //Change role name
                role.Name = model.RoleName;
                var result = await roleManager.UpdateAsync(role);

                if (result.Succeeded)
                {
                    //Redirect to the ListRoles view, updating the model
                    return RedirectToAction("ListRoles");
                }

                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View(model);

            }

        }

        //Delete role
        [HttpPost]
        public async Task<IActionResult> DeleteRole(string id)
        {
            //Pass in id and set it to "role" variable
            var role = await roleManager.FindByIdAsync(id);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {id} cannot be found";
                return View("NotFound");
            }
            else
            {
                //Using DeleteAsync() method to delte role
                var result = await roleManager.DeleteAsync(role);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListRoles");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View("ListRoles");
            }
        }

        //Edit the users associated with the selected role
        [HttpGet]
        public async Task<IActionResult> EditUsersInRole(string roleId)
        {
            //Using viewbag to pass the roleId from the view to the controller
            ViewBag.roleId = roleId;

            //Using roleManager to get the role variable populated with the info for the role
            var role = await roleManager.FindByIdAsync(roleId);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with ID = {roleId} cannot be found";
                return View("NotFound");
            }

            //Creating instance of a list of UserRoles
            var model = new List<UserRole>();

            //Loop through each user in the database to check if they are in the role
            foreach(var user in userManager.Users)
            {
                var userRole = new UserRole
                {
                    UserId = user.Id,
                    UserName = user.UserName
                };

                //If user in is the selected role, then IsSelected checkbox will be checked
                if(await userManager.IsInRoleAsync(user, role.Name))
                {
                    userRole.IsSelected = true;
                }
                //Otherwise the checkbox will be empty
                else
                {
                    userRole.IsSelected = false;
                }
                //Add all the roles to the model
                model.Add(userRole);
            }
            return View(model);
        }

        //Post method to handle post request of the editusersinrole
        [HttpPost]
        public async Task<IActionResult> EditUsersInRole(List<UserRole> model, string roleId) //Passing in UserRoles and roleId
        {
            //Set role equal to the role, as determined by the roleId
            var role = await roleManager.FindByIdAsync(roleId);

            //Return error page if the role is null
            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with ID = {roleId} cannot be found";
                return View("NotFound");
            }

            //Loop through each model
            for (int i = 0; i < model.Count; i++)
            {
                var user = await userManager.FindByIdAsync(model[i].UserId);

                IdentityResult result = null;
                
                //Check to see if user is selected and if they are not already in the role
                if(model[i].IsSelected && !(await userManager.IsInRoleAsync(user, role.Name)))
                {
                    result = await userManager.AddToRoleAsync(user, role.Name);
                }
                //Else if user is not selected and already in the role, remove him/her
                else if (!model[i].IsSelected && await userManager.IsInRoleAsync(user, role.Name))
                {
                    result = await userManager.RemoveFromRoleAsync(user, role.Name);
                }
                else
                {
                    continue;
                }


                if (result.Succeeded)
                {
                    //keep looping if 'i' is less that the amount of usrs
                    if (i < (model.Count - 1))
                        continue;
                    else // else loop is done and redirect to the editrole view
                        return RedirectToAction("EditRole", new { Id = roleId });
                }
            }

            return RedirectToAction("EditRole", new { Id = roleId });
        }

        //Get method to display ListUsers view
        [HttpGet]
        public IActionResult ListUsers()
        {
            var users = userManager.Users;
            return View(users);
        }

        //Get method to display EditUser view
        [HttpGet]
        public async Task<IActionResult> EditUser(string id)
        {
            var user = await userManager.FindByIdAsync(id);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {id} cannot be found";
                return View("NotFound");
            }

            //Returning the list of user Roles
            var userRoles = await userManager.GetRolesAsync(user);

            //Bringing in the EditUser model
            var model = new EditUser
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Roles = userRoles
            };

            return View(model);
        }

        //Posting form for EditUser view, passing in the EditUser model
        [HttpPost]
        public async Task<IActionResult> EditUser(EditUser model)
        {
            //Set user equal to the id that was passed from the view
            var user = await userManager.FindByIdAsync(model.Id);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {model.Id} cannot be found";
                return View("NotFound");
            }
            else
            {
                //Updating the email, username, fname, and lname of user
                user.Email = model.Email;
                user.UserName = model.UserName;
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;

                //Update the user to the result variable - using UpdateAsync method
                var result = await userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListUsers");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View(model);
            }
        }

        //Deleting the user, passing in the id associated with the user from the view
        [HttpPost]
        public async Task<IActionResult> DeleteUser(string id)
        {
            //FindByIdAsync method to get the user information and set it to user variable
            var user = await userManager.FindByIdAsync(id);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {id} cannot be found";
                return View("NotFound");
            }
            else
            {
                //Deleting the user
                var result = await userManager.DeleteAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListUsers");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View("ListUsers");
            }
        }

        //Handles the ManageUserRoles view, passing in the userId
        [HttpGet]
        public async Task<IActionResult> ManageUserRoles(string userId)
        {
            //Viewbag connects view to controller
            ViewBag.userId = userId;

            //Set the user to the user wit the userId that was passed in
            var user = await userManager.FindByIdAsync(userId);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {userId} cannot be found";
                return View("NotFound");
            }

            //Set model to  instance of mangeruserroles model
            var model = new List<ManageUserRoles>();

            //Loop through all the roles to display
            foreach (var role in roleManager.Roles)
            {
                var userRolesViewModel = new ManageUserRoles
                {
                    RoleId = role.Id,
                    RoleName = role.Name
                };
                
                //Set boolean to true if the user is part of the role
                if (await userManager.IsInRoleAsync(user, role.Name))
                {
                    userRolesViewModel.IsSelected = true;
                }
                //Else set the boolean checkbox to false
                else
                {
                    userRolesViewModel.IsSelected = false;
                }

                model.Add(userRolesViewModel);
            }

            return View(model);
        }

        //Post method to update the users in each role - passing in the ManageUserRoles model and the userId
        [HttpPost]
        public async Task<IActionResult>ManageUserRoles(List<ManageUserRoles> model, string userId)
        {
            //Set the user to 
            var user = await userManager.FindByIdAsync(userId);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {userId} cannot be found";
                return View("NotFound");
            }

            //Get the user's roles
            var roles = await userManager.GetRolesAsync(user);
            //Remove the user's roles
            var result = await userManager.RemoveFromRolesAsync(user, roles);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot remove user existing roles");
                return View(model);
            }

            //Add all selected roles to user - using linq query to get only those that are selected
            result = await userManager.AddToRolesAsync(user,
                model.Where(x => x.IsSelected).Select(y => y.RoleName));

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot add selected roles to user");
                return View(model);
            }

            return RedirectToAction("EditUser", new { Id = userId });
        }
    }
}
