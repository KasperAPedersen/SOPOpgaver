using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using static OpgaveIOOPOgDatabase.CRender;

namespace OpgaveIOOPOgDatabase
{
    internal class CTable : CObject
    {
        public Alignment alignment { get; set; } = Alignment.None;
        
        public List<string> headers = [];
        public List<List<string>> contents = [];

        int currentHeight = 0;

        int maxPerPage = 26;
        int currentPage = 0;

        public int contentIndex { get; set; } = 0;
        public int selectIndex { get; set; } = 1;


        internal void Render()
        {

            if (alignment != Alignment.None && parent != null) // If alignemt is set, update positioning
            {
                position = Align(this, parent, alignment);
                absPosition = new Position(absPosition.Horizontal + position.Horizontal, absPosition.Vertical + position.Vertical);
            }

            if (parent != null) // If parent exists, update positioning
            {
                position.Horizontal = Math.Max(1, position.Horizontal);
                position.Vertical = Math.Max(1, position.Vertical);
            }

           
            // If size exceeds parent size, update size
            if (position.Vertical + size.Vertical > (parent?.size.Vertical ?? Console.WindowHeight))
                size.Vertical = (parent?.size.Vertical ?? Console.WindowHeight) - absPosition.Vertical - 2;
            // --

            Erase(new Position(position.Horizontal, position.Vertical), new Size(size.Horizontal + position.Horizontal - 12, size.Vertical)); // Clear screen for position & size of element
            
            if (selectIndex > 11) selectIndex = 10;
            if (selectIndex < 10) selectIndex = 11;

            if (contentIndex > contents.Count - 1) // If contenIndex is last, contentIndex & currentpage to 0
            {
                contentIndex = 0;
                currentPage = 0;
            }

            if (contentIndex < 0) // if contentIndex is first, set contentIndex & currentpage to last
            {
                contentIndex = contents.Count - 1;
                currentPage = contents.Count / maxPerPage;
            }

            if (contentIndex > (currentPage + 1) * maxPerPage - 1) currentPage++; // If contentIndex is last on page, increase currentpage
            if (contentIndex < ((currentPage + 1) * maxPerPage) - maxPerPage && currentPage > 0) currentPage--; // if contentIndex is first on page, decrease currentpage

            string tmp;
            int tabWidth = size.Horizontal / headers.Count - 1; // Calculate max tab width

            // headers
            for(int i = 0; i < headers.Count; i++)
            {
                currentHeight = 0;
                tmp = i == 0 ? Border(Get.TopLeft).ToString() : Border(Get.HorizontalDown).ToString(); // Set string to begin with #
                tmp += new string(Border(Get.Horizontal), tabWidth - 1); // Add # for the tab width
                tmp += i == headers.Count - 1 ? Border(Get.TopRight) : ""; // If header is the last one, add # to string
                Write(new Position(absPosition.Horizontal + (i * tabWidth), absPosition.Vertical + currentHeight++), tmp); // Write string to screen

                tmp = Border(Get.Vertical).ToString(); // Set string to begin with #
                tmp += new string(' ', (tabWidth - headers[i].Length) / 2); // Add left side spacing to string
                tmp += headers[i]; // Add header text to string
                tmp += new string(' ', (tabWidth - 1 - headers[i].Length) / 2); // Add right side spacing to string
                tmp += i == headers.Count - 1 ? Border(Get.Vertical) : ""; // If header is the last one, add # to string
                Write(new Position(absPosition.Horizontal + (i * tabWidth), absPosition.Vertical + currentHeight++), tmp); // Write string to screen

                tmp = i == 0 ? Border(Get.VerticalLeft).ToString() : Border(Get.Cross).ToString(); // Set string to begin with #
                tmp += new string(Border(Get.Horizontal), tabWidth - 1); // Add # for the tab width
                tmp += i == headers.Count - 1 ? Border(Get.VerticalRight) : ""; // If header is the last one, add # to string
                Write(new Position(absPosition.Horizontal + (i * tabWidth), absPosition.Vertical + currentHeight++), tmp); // Write string to screen
            }

            // contents
            for(int i = (currentPage + 1) * maxPerPage - maxPerPage; i < contents.Count; i++)
            {
                if (i > (currentPage + 1) * maxPerPage - 1) break;
                if (i > contents.Count || i < 0) break;

                if (currentHeight + 3 < size.Vertical)
                {
                    for(int o = 0; o < headers.Count; o++)
                    {
                        string contentText = (o > contents[i].Count - 1) ? "SWP" : contents[i][o]; // Set content text to swp if o > content items

                        if (o == headers.Count - 2) contentText = "Edit"; // if o is second last, set content text to edit
                        if (o == headers.Count - 1) contentText = "Slet"; // if o is last, set content text to slet

                        if (contentIndex == i && selectIndex == o) contentText = $"> {contentText}"; // if content & select is active, add > to content text

                        
                        tmp = Border(Get.Vertical).ToString(); // Set string to begin with #
                        tmp += new string(' ', (tabWidth - contentText.Length) / 2); // Add left side spacing to string
                        tmp += contentText; // Add content text to string
                        tmp += new string(' ', (tabWidth - contentText.Length) / 2); // Add right side spacing to string
                        if (o == headers.Count - 1) tmp = tmp.Substring(0, tmp.Length - 1); // If tab is last one, remove 1 spacing after content text
                        tmp += Border(Get.Vertical); // Add # to the end of the string
                        Write(new Position(absPosition.Horizontal + (o * tabWidth), absPosition.Vertical + currentHeight), tmp); // Write string to screen
                    }
                    currentHeight++; // Increase the height
                }
            }

            // Write footer border top to screen
            for (int i = 0; i < headers.Count; i++)
            {
                tmp = i == 0 ? Border(Get.VerticalLeft).ToString() : Border(Get.HorizontalUp).ToString();
                tmp += new string(Border(Get.Horizontal), tabWidth - 1);
                tmp += i == headers.Count - 1 ? Border(Get.VerticalRight) : "";
                Write(new Position(absPosition.Horizontal + (i * tabWidth), absPosition.Vertical + currentHeight), tmp);
            }

            string footerText = $"Page {currentPage + 1}/{((contents.Count / maxPerPage + (contents.Count % maxPerPage == 0 ? 0 : 1)) == 0 ? 1 : contents.Count / maxPerPage + (contents.Count % maxPerPage == 0 ? 0 : 1))}";
            int footerSpacingRemainder = (tabWidth * headers.Count - 1 - footerText.Length) % 2; // Calculates the remainder of the spacing
            string footerSpacing = new string(' ', (tabWidth * headers.Count - 1 - footerText.Length) / 2); // Spacing for each side of the footer text

            // Write footer content to screen
            tmp = $"{Border(Get.Vertical)}{footerSpacing}{footerText}{footerSpacing}{(footerSpacingRemainder != 0 ? new string(' ', footerSpacingRemainder) : "")}{Border(Get.Vertical)}";
            Write(new Position(absPosition.Horizontal, absPosition.Vertical + ++currentHeight), tmp);

            // Write footer border bottom to screen
            tmp = $"{Border(Get.BottomLeft)}{(new string(Border(Get.Horizontal), tabWidth * headers.Count - 1))}{Border(Get.BottomRight)}";
            Write(new Position(absPosition.Horizontal, absPosition.Vertical + ++currentHeight), tmp);

        }

        internal void Reset()
        {
            contents.Clear();
            Render();
        }

        internal void Fetch()
        {
            Reset();

            List<List<string>> result = CDatabase.Read1("SELECT customer.id, customer.FirstName, customer.LastName, customer.Street, " +
                "city.CityName, city.PostalCode, " +
                "schools.schoolsName, education.educationEnd, " +
                "jobs.JobName, employment.EmploymentStart, employment.EmploymentEnd " +
                "FROM customer, city, schools, education, jobs, employment " +
                "WHERE city.PostalCode = customer.PostalID AND education.customerid = customer.id " +
                "AND schools.educationID = education.educationName AND employment.customerid = customer.id " +
                "AND jobs.JobID = employment.EmploymentName", ["FirstName", "LastName", "Street", "CityName", "PostalCode", "schoolsName", "educationEnd", "JobName", "EmploymentStart", "EmploymentEnd"]);


            for (int i = 0; i < result.Count; i++)
            {

                List<string> tmp = result[i];
                for (int o = 0; o < result[i].Count; o++)
                {
                    if (tmp[o].Length > 10)
                    {
                        tmp[o] = tmp[o].Substring(0, 11);
                    }
                }
                contents.Add(tmp);
            }

            Render();
        }
    }
    internal class CTableBuilder
    {
        private CTable table = new();
        public CTable Build()
        {
            table.Fetch();
            return table;
        }
        public CTableBuilder AddPosition(int x, int y)
        {
            Position position = new Position(x, y);
            table.position = position;
            table.absPosition = new Position((table.parent?.absPosition.Horizontal ?? 0) + table.position.Horizontal, (table.parent?.absPosition.Vertical ?? 0) + table.position.Vertical);
            return this;
        }

        public CTableBuilder AddSize(int width, int height)
        {
            Size size = new Size(width, height);
            table.size = size;
            return this;
        }

        public CTableBuilder AddParent(CObject parent)
        {
            table.parent = parent;
            table.absPosition = new Position((table.parent?.absPosition.Horizontal ?? 0) + table.position.Horizontal, (table.parent?.absPosition.Vertical ?? 0) + table.position.Vertical);
            return this;
        }

        public CTableBuilder AddHeader(string header)
        {
            table.headers.Add(header);
            return this;
        }

        public CTableBuilder AddHeaders(List<string> headers)
        {
            foreach(string s in headers)
            {
                table.headers.Add(s);
            }
            return this;
        }

        public CTableBuilder AddContent(List<string> content)
        {
            table.contents.Add(content);
            return this;
        }

        public CTableBuilder AddAlignment(Alignment align)
        {
            table.alignment = align;
            return this;
        }
    }
}
