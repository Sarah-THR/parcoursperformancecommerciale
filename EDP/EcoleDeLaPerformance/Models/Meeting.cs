using Microsoft.Graph;

namespace EcoleDeLaPerformance.Ui.Models
{
    public class Meeting
    {
        public int MeetingId { get; set; }
        public bool? Type { get; set; } // True = Rendez-vous à venir ; False = Rendez-vous réalisés
        public string TypeText
        {
            get
            {
                switch (Type)
                {
                    case true:
                        return "Rendez-vous à venir";
                    case false:
                        return "Rendez-vous réalisés";
                    default:
                        return "Inconnu";
                }
            }
        }

        public int number { get; set; }
    }
}
