using System.Collections.Generic;

namespace Ihc.Common
{
    /// <summary>
    /// Result of one page and the total number of results 
    /// </summary>
    /// <typeparam name="T">Type of entity</typeparam>
    // Class can be extended with ideas from these links:
    // http://webcache.googleusercontent.com/search?q=cache:X4-R8B5ar5UJ:blogs.planetcloud.co.uk/mygreatdiscovery/post/Simple-paging-with-ASPNET-MVC-and-NHibernate.aspx+asp.net+nhibernate+paging&hl=en&gl=be&strip=1
    // http://weblogs.asp.net/gunnarpeipman/archive/2010/09/14/returning-paged-results-from-repositories-using-pagedresult-lt-t-gt.aspx
    // http://rookian.com/wordpressBlog/index.php/2010/09/25/paging-with-nhibernate-3-0-using-the-new-query-api-queryover/
    // http://weblogs.asp.net/stefansedich/archive/2008/10/03/paging-with-nhibernate-using-a-custom-extension-method-to-make-it-easier.aspx
    // http://blogs.planetcloud.co.uk/mygreatdiscovery/post/Simple-paging-with-ASPNET-MVC-and-NHibernate.aspx
    public class PagedList<T>
    {
        ///<summary>
        /// Create a new PagedList
        ///</summary>
        ///<param name="results">Results</param>
        ///<param name="pageIndex">Index of the page</param>
        ///<param name="pageSize">Size of each page</param>
        ///<param name="totalItems">Total number of items</param>
        public PagedList(IEnumerable<T> results, int pageIndex, int pageSize, int totalItems)
        {
            Results = results;
            TotalItems = totalItems;
            PageIndex = pageIndex;
            PageSize = pageSize;
        }

        ///<summary>
        /// Total of all items in the database
        ///</summary>
        public int TotalItems { get; private set; }

        ///<summary>
        /// Items for the requested page
        ///</summary>
        public IEnumerable<T> Results { get; private set; }

        /// <summary>
        /// Index of the requested page
        /// </summary>
        public int PageIndex { get; private set; }

        /// <summary>
        /// Size of each page
        /// </summary>
        public int PageSize { get; private set; }
    }
}