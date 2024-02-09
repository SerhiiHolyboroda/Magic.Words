namespace BlazorMagicWords.Components.Data {
    public class JobModel {

        public int Id { get; set; }

        public JobStatuses Status { get; set; }

        public string Detail { get; set; }

        public DateTime UpdatedTime { get; set; }

        public enum JobStatuses {
            Todo,
            Started,
            Completed
        }
    }
}
