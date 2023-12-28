namespace Project
{
    public class ArtInspector : IPrintable
    {
        int? rating;
        public int? Rating
        {
            get { return rating; }
            set
            {
                rating = value;
                OnRatingChanged?.Invoke(this, EventArgs.Empty);
            }
        }
        public event EventHandler OnRatingChanged;
        public ArtGallery ArtGallery { get; set; }
        public ArtInspector(ArtGallery artGallery, int? rating) 
        {
            Rating = rating;
            ArtGallery = artGallery;
        }
        public Func<string> ToStringDelegate => () =>
        {
            if (Rating == null)
            {
                return $"Галерея: {ArtGallery.Name} - не оцiнена";
            }
            else
                return $"Галерея: {ArtGallery.Name}, рейтинг - {Rating}";
        };
        public static Func<int, List<ArtInspector>, int> Action = (count, list) =>
        {
            foreach (var item in list)
            {
                if (item.Rating != null) count++;
            }
            return count;
        };
        public string PrintToDisplay()
        {
            string result;
            if (Rating == null)
            {
                result = $"Галерея: {ArtGallery.Name} - не оцiнена";
            }
            else
                result = $"Галерея: {ArtGallery.Name}, рейтинг - {Rating}";
            result += $"\n{ArtGallery.PrintToDisplay()}";
            return result;
        }
    }
}
