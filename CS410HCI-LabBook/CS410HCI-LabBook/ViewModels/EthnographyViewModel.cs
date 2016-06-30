using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS410HCI_LabBook.ViewModels {
    public class EthnographyViewModel {
        public List<LineItem> Notes = new List<LineItem> {
            new LineItem { time = "5:22", note = "A user is checking out with a tool. Volunteer asks for the user's first and last name and looks the user up. Then, the volunteer asks the user for the tool number. The volunteer marks the tool as checked out by the user in a web application, then tells the user the tool is due back in 1 week." },
            new LineItem { time = "5:24", note = "An existing user enters the library. A volunteer asks the user if they can confirm the user's email and address with the details they have in their web application. " },
            new LineItem { time = "5:27", note = "New user: the volunteer asks the new user for their full name, enters that into their system, then asks for a driver's license with a current address on it. Volunteer asks for a one-time donation. " },
            new LineItem { time = "5:29", note = "The new user from above looks at rakes and brooms next to the front desk area. " },
            new LineItem { time = "5:30", note = "An existing user enters the library to return tools. The volunteer confirms tool numbers, and checks them back in. The volunteer tells the user to place the tools back where they previously picked them up (on the shelves). The volunteer helps put some of the tools back because the user could not remember where they all go." },
            new LineItem { time = "5:32", note = "User asks for availability and whereabouts of a weed whacker." },
            new LineItem { time = "5:33", note = "User comes in to return items, volunteer asks for tool numbers, user asks where to place returned items." },
            new LineItem { time = "5:35", note = "User asks for the time that a workshop is happening: “Tool repair workshop”." },
            new LineItem { time = "5:36", note = "*my own observation: tools are organized in sections placed on the wall. A tool-category (eg shovels, drills) to section-number map is in the volunteer area." },
            new LineItem { time = "5:37", note = "User returns a tool. Tool has no number on it. Volunteer asks for the user's name. The volunteer checks the tool in simply by tool description since no number exists (it is an orange caulking gun, entered simply as “the orange one”). Volunteer does not issue a number for the tool. " },
            new LineItem { time = "5:39", note = "User returns a tool, volunteer asks for # and confirms contents of hole saw case. Volunteer asks user if they remember where the hold saw was picked up. User confirms they do, and the user places the tool back." },
            new LineItem { time = "5:41", note = "User wants to renew a late tool without returning the tool. Renewal requires the tool is brought back. Volunteer ended up pretending the tool was “returned”, the user paid a late fee, and the volunteer renewed the tool checkout for another week." },
            new LineItem { time = "5:42", note = "User asks for black electrical tape – none available." },
            new LineItem { time = "5:44", note = "New user created SEPTL account online. However, volunteer cannot find the account by name. Volunteer creates a new account for the user. User donates $20." },
            new LineItem { time = "5:45", note = "User returns tools – volunteer confirms #s, confirms tool descriptions with user. User places tools back. " },
            new LineItem { time = "5:46", note = "User asks for edger, volunteer helps user find one." },
            new LineItem { time = "5:47", note = "User comes in and debates late fee. Volunteers forgive late fee. User agrees to donate amount of late fee next time they come in (has no cash on hand currently to donate)." },
            new LineItem { time = "5:49", note = "User looks at push mowers, weighs them by picking them up slightly. User picks the lightest one." },
            new LineItem { time = "5:50", note = "User asks for circular saw and crowbar. Volunteer helps user find them." },
            new LineItem { time = "5:50", note = "*my own observation: Volunteers usually ask users to place tools back." },
            new LineItem { time = "5:51", note = "User looks around silently, picks up 1/2” drill. Seems like the user is looking for a certain size drill for something." },
            new LineItem { time = "5:56", note = "New user signed up online. Brings in mail to prove address. Brings cash donation as well." },
            new LineItem { time = "", note = "" },
            new LineItem { time = "", note = "" },
            new LineItem { time = "", note = "" },
            new LineItem { time = "", note = "" },
            new LineItem { time = "", note = "" },
            new LineItem { time = "", note = "" },
            new LineItem { time = "", note = "" },
        };
    }

    public class LineItem {
        public string time { get; set; }
        public string note { get; set; }
    }
}
