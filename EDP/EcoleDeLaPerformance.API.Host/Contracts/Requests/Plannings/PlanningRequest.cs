﻿namespace EcoleDeLaPerformance.API.Host.Contracts.Requests.Plannings
{
    public class PlanningRequest
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
