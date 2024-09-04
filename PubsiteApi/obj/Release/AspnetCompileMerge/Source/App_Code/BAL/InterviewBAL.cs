using System;
using System.Collections.Generic;
using System.Web;
using PubsiteApi.App_Code.DAL;


public class InterviewBAL
{
    InterviewDAL objInterviewDAL = new InterviewDAL();
    public void AddData()
    {

        try { objInterviewDAL.AddData(); }
        catch (Exception ex)
        {

        }

    }

}