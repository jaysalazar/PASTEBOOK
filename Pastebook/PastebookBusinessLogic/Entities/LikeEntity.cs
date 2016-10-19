namespace PastebookBusinessLogic.Entities
{
    public class LikeEntity
    {
        public int LikeId { get; set; }

        public int PostId { get; set; }

        public int LikedBy { get; set; }
    }
}
