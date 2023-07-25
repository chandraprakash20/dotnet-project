using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class faq_tableEntities
{
    private int faqIDPK = 0;
    private string faqQuestions = "";
    private string faqAnswers = "";
    private string addedOn = "";
    private int isActive = 0;

    public int FaqIDPK { get => faqIDPK; set => faqIDPK = value; }
    public string FaqQuestions { get => faqQuestions; set => faqQuestions = value; }
    public string FaqAnswers { get => faqAnswers; set => faqAnswers = value; }
    public string AddedOn { get => addedOn; set => addedOn = value; }
    public int IsActive { get => isActive; set => isActive = value; }
}

    