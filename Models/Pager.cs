namespace Taskscheduler.Models
{
    public class Pager
    {
        public int Totalitems { get;private set; }
        public int Currentpage { get; private set; }
        public int Totalpages { get; private set;}
        public int Pagesize { get; private set; }
        public int Startpage {  get; private set; }
        public int Endpage { get; private set;}
        public Pager()
        {

        }
        public Pager(int totalitems, int page,  int pagesize = 10)
        {
            int totalpages = (int)Math.Ceiling((decimal)totalitems /(decimal)pagesize);
            int currentpage = page;
            int startpage = currentpage - 5;
            int endpage = currentpage + 4;
            if(startpage <= 0)
            {
                endpage = endpage - (startpage - 1);
                startpage = 1;
            }
            if(endpage > totalpages)
            {
                endpage = totalpages;
                if(endpage > 10)
                {
                    startpage = endpage - 9;
                }
            }
            Totalitems = totalitems;
            Currentpage = currentpage;
            Startpage = startpage; 
            Endpage = endpage;
            Pagesize = pagesize;
            Totalpages = totalpages;
        }
    }
}
