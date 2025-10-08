namespace DNDApi.Api.v1.DTO.HeroDTO
{
    public class HeroResponse
    {
        public int HeroID;
        public int UserID;
        public string Race { get; set; } = string.Empty;
        public string Class { get; set; } = string.Empty;
        public string HeroName { get; set; } = string.Empty;
        public string HeroSide { get; set; } = string.Empty;
        public string HeroBorn { get; set; } = string.Empty;
        public string HeroHistory { get; set; } = string.Empty;
        public string HeroAvatar { get; set; } = string.Empty;
        public ParamsResponse HeroParams { get; set; } = new();
    }
}