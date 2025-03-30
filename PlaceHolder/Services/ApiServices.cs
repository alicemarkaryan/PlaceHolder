using PlaceHolder.Models;

namespace PlaceHolder.Services
{
    public class ApiService
    {

        private static readonly List<Post> posts =
    [
        new Post { Id = 1, UserId = 1, Title = "Post 1 Title"},
        new Post { Id = 2, UserId = 1, Title = "Post 2 Title"},
        new Post { Id = 3, UserId = 2, Title = "Post 3 Title"},
        new Post { Id = 4, UserId = 2, Title = "Post 4 Title" },
        new Post { Id = 5, UserId = 3, Title = "Post 5 Title"}
    ];

        private static readonly List<User> users =
    [
        new User { Id = 1, FirstName = "Alice", LastName = "Johnson", Email = "alice.johnson@example.com", Avatar = "/images/alice.png", Support = new Support { Url = "https://support.example.com" } },
        new User { Id = 2, FirstName = "Bob", LastName = "Smith", Email = "bob.smith@example.com", Avatar = "/images/bob.png", Support = new Support { Url = "https://support.example.com" } },
        new User { Id = 3, FirstName = "Charlie", LastName = "Davis", Email = "charlie.davis@example.com", Avatar = "/images/charlie.png", Support = new Support { Url = "https://support.example.com" } },
        new User { Id = 4, FirstName = "Diana", LastName = "Martinez", Email = "diana.martinez@example.com", Avatar = "/images/diana.png", Support = new Support { Url = "https://support.example.com" } },
        new User { Id = 5, FirstName = "Ethan", LastName = "Taylor", Email = "ethan.taylor@example.com", Avatar = "/images/ethan.png", Support = new Support { Url = "https://support.example.com" } }
    ];

        public Post? GetDataByUserAndTitle(int userId, string title)
        {
            return posts.FirstOrDefault(_ => _.UserId == userId && _.Title == title);
        }

        public Post? GetDataById(int id)
        {
            return posts.FirstOrDefault(_ => _.Id == id);
        }

        public User CreateUser(User user)
        {
            user.Id = users.Count + 1;

            users.Add(user);

            return user;
        }
        public User? UpdateUser(int id, User updatedUser)
        {
            var user = users.FirstOrDefault(x => x.Id == id);
            if (user != null)
            {
                user.Email = updatedUser.Email;
                user.FirstName = updatedUser.FirstName;
                user.LastName = updatedUser.LastName;
                user.Avatar = updatedUser.Avatar;
                user.Support = updatedUser.Support;
            }

            return user ;
        }

        public Task DeletePostById(int id)
        {
            var post = posts.FirstOrDefault(x => x.Id == id);
            if (post != null)
            {
                var posts = new List<Post>();
                posts.Remove(post);
            }
            return Task.CompletedTask;
        }
    }
}


