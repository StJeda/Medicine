using CourseWorkWeb.Models.Entity.Medicines;

namespace CourseWorkWeb.Core.SmartFilter
{
    public static class MedicineExtensions
    {
        public static IEnumerable<Medicine> MedicineFilter(this IEnumerable<Medicine> medicines, string searchInput)
        {
            if (string.IsNullOrWhiteSpace(searchInput))
                return Enumerable.Empty<Medicine>();

            var result = new List<Medicine>();

            foreach (var medicine in medicines)
            {
                double similarity = CalculateSimilarity(medicine.Name, searchInput) +
                                    CalculateSimilarity(medicine.Description, searchInput) +
                                    CalculateSubstance(medicine.Substances, searchInput);
                if (similarity >= 80.0)
                    result.Add(medicine);
            }

            return result;
        }

        private static double CalculateSimilarity(string source, string target)
        {
            if (string.IsNullOrEmpty(source) || string.IsNullOrEmpty(target))
                return 0.0;

            int sourceLength = source.Length;
            int targetLength = target.Length;
            int[,] distances = new int[sourceLength + 1, targetLength + 1];

            for (int i = 0; i <= sourceLength; i++)
                distances[i, 0] = i;
            for (int j = 0; j <= targetLength; j++)
                distances[0, j] = j;
            for (int i = 1; i <= sourceLength; i++)
                for (int j = 1; j <= targetLength; j++)
                {
                    int cost = source[i - 1] == target[j - 1] ? 0 : 1;
                    distances[i, j] = Math.Min(Math.Min(distances[i - 1, j] + 1, distances[i, j - 1] + 1), distances[i - 1, j - 1] + cost);
                }

            int maxLength = Math.Max(sourceLength, targetLength);
            int distance = distances[sourceLength, targetLength];

            return 100 * (1 - (double)distance / maxLength);
        }

        private static double CalculateSubstance(IEnumerable<Substance> substances, string target)
        {
            if (substances == null || !substances.Any() || string.IsNullOrWhiteSpace(target))
                return 0.0;

            double totalSimilarity = 0.0;

            foreach (var substance in substances)
            {
                double similarity = CalculateSimilarity(substance.Active, target);
                if (similarity > totalSimilarity)
                    totalSimilarity = similarity;
            }

            return totalSimilarity;
        }
    }
}

