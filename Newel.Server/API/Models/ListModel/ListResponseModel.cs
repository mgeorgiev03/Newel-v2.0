namespace API.Models.ListModel
{
    public class ListResponseModel : BaseResponseModel
    {
        public string Name { get; set; }

        public Guid UserId { get; set; }
    }
}
