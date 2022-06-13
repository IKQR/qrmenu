namespace QRCodeMenu.Server.Dto
{
    public class DishesGroupDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<DishDto> Dishes {get;set;}
    }
}
