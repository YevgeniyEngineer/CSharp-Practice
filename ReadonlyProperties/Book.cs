
namespace ReadonlyProperties
{
    public class Book
    {
        // Readonly fields can only be initialized during:
        // 1. default declaration
        // 2. instance constructor
        // 3. static constructor
        private readonly string _isbn = "";
        private readonly string _title = "";
        private readonly string _author = "";

        public Book(string isbn, string title, string author)
        {
            _isbn = isbn;
            _title = title;
            _author = author;
        }

        public string GetBookDetails()
        {
            return $"ISBN: {_isbn}, Title: {_title}, Author: {_author}";
        }
    }
}