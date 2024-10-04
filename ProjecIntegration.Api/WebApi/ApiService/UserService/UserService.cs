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
        private readonly IMapper _mapper;
        public UserService(IManagementApiClient managementApiClient, IMapper mapper)
        {
            _managementApiClient = managementApiClient;
            _mapper = mapper;   
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
        public async Task<ServiceResponse<UserDto>> GetById(string userId)
        {
            ServiceResponse<UserDto> response = new();   
            try
            {

                User apiClient = await _managementApiClient.Users.GetAsync(userId);
                UserDto dto = new UserDto()
                {
                    Email = apiClient.Email,
                    EmailVerified = false,
                    App_metadata = apiClient.AppMetadata,
                    Blocked = false,
                    FamilyName = apiClient.LastName,
                    GivenName = apiClient.FirstName,
                    PhoneVerified = false,
                    UserName = apiClient.FirstName,
                    User_id = apiClient.UserId,
                    UserMetadata = apiClient.UserMetadata,
                    Picture = apiClient.Picture,
                    Name=string.Empty,
                    NickName=string.Empty,
                    Phone_number=string.Empty,
                    VerifyMail=false,

                };
                response.Data =dto;
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
        public async Task<ServiceResponse<User>> UpdateById(string userId,UpdateUserDto userDto)
        {
            ServiceResponse<User> response = new();
            try
            {
                UserUpdateRequest dto = new UserUpdateRequest()
                { 
                    FirstName = userDto.GivenName,
                    FullName = userDto.Name,
                    LastName = userDto.FamilyName,
                    UserName = userDto.UserName,
                    NickName = userDto.NickName,
                };

                dto.SetUserMetadata(userDto.UserMetadata);
                var apiClient = await _managementApiClient.Users.UpdateAsync(userId,dto);
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
                        "rol_s2YviglxvMJ1h1aG"
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
                        "rol_iOKjiSJq4XLgBmxd"
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

        public async Task<ServiceResponse<List<UserDto>>> GetlistId(List<string> stringIds)
        {
            ServiceResponse<List<UserDto>> response = new();
            try
            {
                List<UserDto> GetUserDto= new List<UserDto>();
                IPagedList<User> apiClient = await _managementApiClient.Users.GetAllAsync(new GetUsersRequest(),new PaginationInfo());
                IEnumerable<User> getUsers = apiClient.Where(x => stringIds.Contains(x.UserId));

                foreach (User item in getUsers)
                {
                    UserDto dto = new UserDto()
                    {
                        Email = item.Email,
                        EmailVerified = item.EmailVerified.Value,
                        App_metadata = item.AppMetadata,
                        Blocked = item.Blocked.Value,
                        FamilyName = item.LastName,
                        GivenName = item.FirstName,
                        PhoneVerified = item.PhoneVerified.Value,
                        UserName = item.FirstName,
                        User_id = item.UserId,
                        UserMetadata = item.UserMetadata,
                        Picture = item.Picture,

                    };
                    GetUserDto.Add(dto);

                }
                response.Data = GetUserDto;
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

        public async Task<ServiceResponse<User>> UnBlockedUser(string userId)
        {
            try
            {
                ServiceResponse<User> response = new();
                try
                {
                    //récupérrer le sinformation de l'utilisateur 
                   await _managementApiClient.UserBlocks.UnblockByUserIdAsync(userId);
                    
                    response.Success = true;
                    response.Message = "user successfully unblocked";
                }
                catch (Exception)
                {

                    response.Success = false;
                    response.Message = "an error has occured during the operation";
                }
                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
