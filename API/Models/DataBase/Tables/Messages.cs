namespace API.Models.DataBase.Tables
{
    public class Messages
    {
        public int MessId { get; set; }

        public string Text { get; set; }
        public DateTime DateCreated { get; set; }
        public int UserId { get; set; }

    }
}
