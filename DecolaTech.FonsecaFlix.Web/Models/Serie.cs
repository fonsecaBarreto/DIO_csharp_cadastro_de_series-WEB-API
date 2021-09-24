using DecolaTech.FonsecaFlix.Enums;

namespace DecolaTech.FonsecaFlix.Web.Models
{
    public class SerieModel
    {
        public int Id { get; private set; }
        public string Title { get; init; }
        public string Description { get; init; }
        public int Year { get; init; }
        public bool Excluded { get; init; }
        public Gender Gender { get; init; }

        public SerieModel(){}

        public SerieModel(FonsecaFlix.Models.SerieEntity serie){
            Id = serie.getId();
            Gender = serie.gender;
            Title = serie.title;
            Description = serie.description;
            Year = serie.year;
            Excluded = serie.excluded;
        }

        public void setId(int id){
            this.Id = id;
        }

        public FonsecaFlix.Models.SerieEntity ToSerieEntity(){
            return new FonsecaFlix.Models.SerieEntity(Id, Gender, Title, Description, Year);
        }
    }
}