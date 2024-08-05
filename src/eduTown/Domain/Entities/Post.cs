using NArchitecture.Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    public class Post: Entity<int>
    {
        public Guid UserId { get; set; }
        public int SchoolId { get; set; }
        public int ClassroomId { get; set; }
        public int BranchId { get; set; }
        public int LikeCount { get; set; } 
        public string Message { get; set; }
        public List<string> FilePath { get; set; }
        public bool IsCommentable { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<PostInteraction> PostInteractions { get; set; }
        //public virtual ICollection<PostFiles> PostFiles { get; set; }

        public Post()
        {
        }
    }
}


// using NArchitecture.Core.Persistence.Repositories;
//using System;
//namespace Domain.Entities
//{
//    public class PostFiles : Entity<int>
//    {
//        public int PostId { get; set; }
//        public string FilePath { get; set; }

//        public virtual Post Post { get; set; }

//        public PostFiles()
//        {
//        }
//    }
//}







