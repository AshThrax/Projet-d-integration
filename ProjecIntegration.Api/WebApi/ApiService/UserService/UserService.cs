using ApplicationAnnonce.DTO;
using ApplicationUser.Dto.User;
using Auth0.ManagementApi;
using Auth0.ManagementApi.Models;
using Auth0.ManagementApi.Paging;
using Domain.Entity.publicationEntity;
using Domain.ServiceResponse;
using User = Auth0.ManagementApi.Models.User;
using UserDto = ApplicationUser.Dto.User.UserDto;

namespace WebApi.ApiService.UserService
{
    public class UserService : IUserService
    {
        private readonly IManagementApiClient _managementApiClient;

        public UserService(IManagementApiClient managementApiClient)
        {
            _managementApiClient = managementApiClient;
        }
        /// <summary>
        /// delete a user from the auth0
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<User>> DeleteId(string userId)
        {
            ServiceResponse<User> response = new();
            try
            {

                await _managementApiClient.Users.DeleteAsync(userId);
                
                response.Success = false;
                response.Message = "data sucessfully deleted";

            }
            catch (Exception)
            {
                response.Success = false;
                response.Message = "data sucessfully deleted";
            }
            return response;
        }
        /// <summary>
        /// retrieve a user from auth0
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<User>> GetById(string userId)
        {
            ServiceResponse<User> response = new();   
            try
            {

                User apiClient = await _managementApiClient.Users.GetAsync(userId);
              
                response.Data = apiClient;
                response.Success = true;
                response.Message = "data sucessfully found";
            }
            catch (Exception)
            {
                
                response.Success = false;
                response.Message = "an error has occured during the operation";
               
            }
            return response;
        }
        /// <summary>
        /// send a request to update a user to auth0
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="userDto"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<User>> UpdateById(string userId,UserUpdateRequest userDto)
        {
            ServiceResponse<User> response = new();
            try
            {
                var apiClient = await _managementApiClient.Users.UpdateAsync(userId,userDto);
                response.Success = true;
                response.Message = "data sucessfully updated";
            }
            catch (Exception)
            {
                response.Message = "an error has occured during the operation";
                response.Success = false;
               
            }
            return response;
        }
        /// <summary>
        /// assigna Role to a user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<User>> AssignRoleById(string userId)
        {
            ServiceResponse<User> response = new();
            try
            {
                AssignRolesRequest assignPermissionsRequest = new AssignRolesRequest() 
                {
                    Roles=new string[] 
                    {
                        ""
                    }
                };

                await _managementApiClient.Users.AssignRolesAsync(userId, assignPermissionsRequest);
                response.Message = "permission successfully assigned";
                response.Success = true;
            }
            catch (Exception)
            {
                response.Message = "an error has occured during the operation";
                response.Success = false;
              
            }
            return response;
        }
        /// <summary>
        /// enléve le role que posséde un utilisatuer sur l'application
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<User>> RemoveRoleById(string userId)
        {
            ServiceResponse<User    > response = new();
            try
            {
                AssignRolesRequest assignPermissionsRequest = new AssignRolesRequest()
                {
                    Roles = new string[]
                    {
                        ""
                    }
                };

                await _managementApiClient.Users.RemoveRolesAsync(userId, assignPermissionsRequest);
                response.Message = "permission successfully assigned";
                response.Success = true;
            }
            catch (Exception)
            {
                response.Message = "an error has occured during the operation";
                response.Success = false;

            }
            return response;
        }

        public async Task<ServiceResponse<List<User>>> GetlistId(List<string> stringIds)
        {
            ServiceResponse<List<User>> response = new();
            try
            {
               
                IPagedList<User> apiClient = await _managementApiClient.Users.GetAllAsync(new GetUsersRequest(),new PaginationInfo());
                IEnumerable<User> getUsers = apiClient.Where(x => stringIds.Contains(x.UserId));

                response.Data = getUsers.ToList();
                response.Success = true;
                response.Message = "data sucessfully found";
            }
            catch (Exception)
            {

                response.Success = false;
                response.Message = "an error has occured during the operation";

            }
            return response;
        }

        public async Task<ServiceResponse<User>> BlockedUser(string userId)
        {
            ServiceResponse<User> response = new();
            try
            {
                //récupérrer le sinformation de l'utilisateur 
                var users = await _managementApiClient.Users.GetAsync(userId);
                users.Blocked = true;

                //mettre a jour le profile de lutilisateur 
                UserUpdateRequest updateRequest= new UserUpdateRequest 
                {
                    AppMetadata=users.AppMetadata,
                    Blocked=true,
                    Email=users.Email,
                    EmailVerified=users.EmailVerified,
                    UserMetadata=users.AppMetadata,
                    FirstName=users.FirstName,
                    FullName=users.FullName,
                    LastName=users.LastName,
                    PhoneNumber=users.PhoneNumber,
                    PhoneVerified=users.PhoneVerified,
                    UserName=users.UserName,
                    Picture=users.Picture,
                    NickName=users.NickName,
                    
                };
                await _managementApiClient.Users.UpdateAsync(userId,updateRequest);
                response.Success = true;
                response.Message = "user successfully blocked";
            }
            catch (Exception)
            {

                response.Success = false;
                response.Message = "an error has occured during the operation";
            }
            return response;
        }
    }
}
