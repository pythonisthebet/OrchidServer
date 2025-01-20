using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OrchidServer.DTO
{
    public class Cheracter
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int LevelValue { get; set; }
        public string? ImgId { get; set; }

        public Cheracter() { }
        public Cheracter(Models.Cheracter model)
        {
            this.Id = model.Id;
            this.UserId = model.UserId;
            this.LevelValue = model.LevelValue;
            this.ImgId = model.ImgId;

        }

        public Models.Cheracter GetModel()
        {
            Models.Cheracter newModel = new Models.Cheracter();
            newModel.Id = this.Id;
            newModel.UserId = this.UserId;
            newModel.LevelValue = this.LevelValue;
            newModel.ImgId = this.ImgId;
            return newModel;
        }
    }
}
