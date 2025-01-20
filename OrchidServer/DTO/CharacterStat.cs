namespace OrchidServer.DTO
{
    public class CharacterStat
    {
        public int Id { get; set; }

        public string CName { get; set; } = null!;

        public string CDescription { get; set; } = null!;

        public Class() { }
        public Class(Models.Class model)
        {
            this.Id = model.Id;
            this.CName = model.CName;
            this.CDescription = model.CDescription;
        }

        public Models.Class GetModel()///////////user id does not link to the respectiv user in db need fix!!!!!!
        {
            Models.Class newModel = new Models.Class();
            newModel.Id = this.Id;
            newModel.CName = this.CName;
            newModel.CDescription = this.CDescription;
            return newModel;
        }
    }
}
