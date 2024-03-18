namespace API.Models.DataBase.Views
{
    public class MessageItems
    {
        public int MessId {  get; set; }
            public string Text { get; set; }
            public DateTime DateCreated { get; set; }
            public string UserPermission { get; set; }
    }
}
