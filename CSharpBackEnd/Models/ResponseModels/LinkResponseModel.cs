

using System;

namespace CSharpBackEnd.Models.ResponseModels
{
    public class LinkResponseModel
    {
        public int Id { get; set; }
        public DateTime DateOfParce { get; set; }
        public string Link { get; set; }
        public double MinTimeParce { get; set; }
        public double MaxTimeParce { get; set; }
    }
}
