using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Book : IEquatable<Book>, IComparable, IComparable<Book>
    {
        private readonly int _id;
        private string _author;
        private string _title;
        private int _pages;
        private int _year;


        #region properties
        public string Author
        {
            get
            {
                return _author;
            }
            set
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentNullException($"{nameof(value)} is invalid!");
                _author = value;
            }
        }
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentNullException($"{nameof(value)} is invalid!");
                _title = value;
            }
        }
        public int Pages
        {
            get
            {
                return _pages;
            }
            set
            {
                if (value <= 0) throw new ArgumentNullException($"{nameof(value)} is invalid!");
                _pages = value;
            }
        }
        public int Year
        {
            get
            {
                return _year;
            }
            set
            {
                if (value > DateTime.Today.Year) throw new ArgumentException($"{nameof(value)} is invalid!");
                _year = value;
            }
        }
        #endregion


        public Book(string author, string title, int pages, int year)
        {
            Author = author;
            Title = title;
            Pages = pages;
            Year = year;
            _id = pages + author.GetHashCode() * 3 + title.GetHashCode() * 5 + year * 7;
        }


        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns>True if the specified object is equal to the current object; otherwise, false.</returns>
        public bool Equals(Book other)
        {
            if (ReferenceEquals(other, null) || GetHashCode() != other.GetHashCode()) return false;
            return Author == other.Author && Title == other.Title && Pages == other.Pages && Year == other.Year;
        }
        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>True if the specified object is equal to the current object; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            if ((ReferenceEquals(obj, null)) || typeof(Book) != obj.GetType()) return false;
            return Equals(obj as Book);
        }


        /// <summary>
        /// Compare two objects by the author name
        /// </summary>
        /// <param name="other">object to compare</param>
        /// <returns>1 if the first is higher, -1 if lower and 0 if equal</returns>
        public int CompareTo(Book other) => string.Compare(Title, other.Title);
        /// <summary>
        /// Compare two objects by the author name
        /// </summary>
        /// <param name="obj">object to compare</param>
        /// <returns>1 if the first is higher, -1 if lower and 0 if equal</returns>
        public int CompareTo(object obj)
        {
            if (ReferenceEquals(obj, null) || typeof(Book) != obj.GetType()) throw new ArgumentNullException($"{nameof(obj)} is invalid!");
            return CompareTo(obj as Book);
        }


        /// <summary>
        /// Return the hash code for current object
        /// </summary>
        public override int GetHashCode() => _id;


        /// <summary>
        /// Return string representation of current object
        /// </summary>
        public override string ToString() => $"Book: {Title}, author: {Author}, year of publishing: {Year}, number of pages: {Pages}";
    }
}