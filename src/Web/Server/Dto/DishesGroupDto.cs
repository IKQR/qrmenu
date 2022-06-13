namespace QRCodeMenu.Server.Dto
{
    public record DishesGroupDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<DishDto> Dishes {get;set;}
    }
}
