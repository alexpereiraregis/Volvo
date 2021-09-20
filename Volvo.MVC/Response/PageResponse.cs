using System.Collections.Generic;

namespace Volvo.MVC.Response
{
    public class PageResponse<T>
    {
        public IEnumerable<T> List { get; set; }

        public T Obj { get; set; }

    }
}
