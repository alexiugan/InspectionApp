namespace InspectionApi.ViewModels
{
    public class InspectionViewModel
    {
        public int? Id { get; set; }
        public string Status { get; set; } = string.Empty;
        public string Comments { get; set; } = string.Empty;
        public int InspectionTypeId { get; set; }
    }
}
