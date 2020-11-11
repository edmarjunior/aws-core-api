namespace Schedule.Api.Dto.Request
{
    public class DocumentRequestDto
    {
        public int ProviderId { get; set; }
        public string Name { get; set; }
        public string FileBase64 { get; set; }
    }
}
