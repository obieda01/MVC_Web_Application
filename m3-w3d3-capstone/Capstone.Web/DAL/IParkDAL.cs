using Capstone.Web.Models;
using System.Collections.Generic;

namespace Capstone.Web.DAL
{
    public interface IParkDAL
    {
        List<Park> getAllParksData();

        Park getParkIdData(string parkCode);
    }
}