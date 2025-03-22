using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using PlaceHolder.Models;

namespace PlaceHolder.Services
{
    public class ApiService
    {
        public List<Post> GetDataByUserAndTitle(int userId, string title)
        {
            return new List<Post>() { new() { Id = userId, Title = title } };
        }

        public Post? GetDataById(int id)
        { 
            return new List<Post>().Where(x => x.Id == id).FirstOrDefault();
        }

        public List<User> CreateUser(User user)
        {
            var data = new List<User>()
            {
                new ()
                {
                    Id = user.Id,
                    Avatar = user.Avatar,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Support= user.Support
                }
            };

            return data;
        }

        public List<User> UpdateUser(int id, User updatedUser)
        {
            var user = new List<User>().FirstOrDefault(x => x.Id == id);
            if (user != null)
            {
                user.Email = updatedUser.Email;
                user.FirstName = updatedUser.FirstName;
                user.LastName = updatedUser.LastName;
                user.Avatar = updatedUser.Avatar;
                user.Support = updatedUser.Support;
            }

            return new List<User> { user };
        }

        public Task DeletePostById(int id)
        {
            var post = new List<Post>().FirstOrDefault(x => x.Id == id);
            if (post != null)
            {
                var posts = new List<Post>();
                posts.Remove(post);
            }
            return Task.CompletedTask;
        }
    }
}


