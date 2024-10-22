﻿using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;

using (FileStream inputFileStream = new FileStream(Path.GetFullPath("Data/Template.docx"), FileMode.Open, FileAccess.ReadWrite))
{
    //Opens the template Word document.
    using (WordDocument document = new WordDocument(inputFileStream, FormatType.Docx))
    {
        //Retrieve the last section of the document.
        IWSection section = document.LastSection;
        //Retrieve the first table from the section.
        IWTable table = section.Body.Tables[0];
        //Iterate through each row in the table.
        foreach (WTableRow row in table.Rows)
        {
            //Set the row height type to "AtLeast" and height to 0 to minimize height.
            row.HeightType = TableRowHeightType.AtLeast;
            row.Height = 0;
            //Iterate through each cell in the row.
            foreach (WTableCell cell in row.Cells)
            {
                //Remove top and bottom margins of the cell.
                cell.CellFormat.Paddings.Top = 0;
                cell.CellFormat.Paddings.Bottom = 0;
                //Iterate through paragraphs in each cell.
                foreach (IWParagraph paragraph in cell.Paragraphs)
                {
                    paragraph.BreakCharacterFormat.FontSize = 8;
                }
            }
        }
        //Save the document.
        using (FileStream outputFileStream = new FileStream(Path.GetFullPath("Output/Result.docx"), FileMode.Create, FileAccess.Write))
        {
            document.Save(outputFileStream, FormatType.Docx);
        }
    }
}