namespace OrchidServer.DTO
{
    public class FiltersToCharacter
    {
        public int Id { get; set; }

        public int? CharacterId { get; set; }

        public int? FilterId { get; set; }


        public FiltersToCharacter() { }

        public FiltersToCharacter(Models.FiltersToCharacter model)
        {
            this.Id = model.Id;
            this.CharacterId = model.CharacterId;
            this.FilterId = model.FilterId;
        }

        public Models.FiltersToCharacter GetModel()
        {
            Models.FiltersToCharacter newModel = new Models.FiltersToCharacter();
            newModel.Id = this.Id;
            newModel.CharacterId = this.CharacterId;
            newModel.FilterId = this.FilterId;
            return newModel;
        }
    }
}
