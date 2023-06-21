namespace test.ModelsDTO
{
    public class PictureDTO
    {
        public int Id { get; set; }
        public string Photo { get; set; } = string.Empty;
        public static PictureDTO ToPictureDTO(Picture p)
        {
            return new PictureDTO
            {
                Id = p.Id,
                Photo= p.Photo
            };
        }
        public Picture ToPicture()
        {
            return new Picture
            {
                Id = Id,
                Photo = Photo
            };
        }
    }
}
