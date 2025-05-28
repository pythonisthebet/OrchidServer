namespace OrchidServer.DTO
{
    public class Filter
    {
        public int Id { get; set; }
        public string Fname { get; set; } = null!;

        public Filter() { }

        public Filter(Models.Filter model)
        {
            this.Id = model.Id;
            this.Fname = model.Fname;
        }

        public Models.Filter GetModel()
        {
            Models.Filter newModel = new Models.Filter();
            newModel.Id = this.Id;
            newModel.Fname = this.Fname;
            return newModel;
        }
    }
}
