using CourseWorkWeb.Models.Entity.Medicines;

namespace CourseWorkWeb.Core.SmartFilter
{
    public static class DescribeExtension
    {
        public static IEnumerable<Medicine> DescribeSearch(this IEnumerable<Medicine> medicines, string word)
        {
            var searchWords = word.Split('/');
            foreach (var searchWord in searchWords)
                medicines = medicines.Where(medicine => medicine.Articules.Contains(searchWord));
            return medicines;
        }

    }
}
