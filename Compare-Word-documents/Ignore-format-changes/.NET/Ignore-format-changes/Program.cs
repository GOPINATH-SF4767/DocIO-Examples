﻿using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;

namespace Ignore_format_changes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Open the Original file as Stream.
            using (FileStream originalDocumentStreamPath = new FileStream(Path.GetFullPath(@"Data/OriginalDocument.docx"), FileMode.Open, FileAccess.Read))
            {
                //Loads Original file stream into Word document.
                using (WordDocument originalDocument = new WordDocument(originalDocumentStreamPath, FormatType.Docx))
                {
                    //Open the Revised file as Stream
                    using (FileStream revisedDocumentStreamPath = new FileStream(Path.GetFullPath(@"Data/RevisedDocument.docx"), FileMode.Open, FileAccess.Read))
                    {
                        //Loads Revised file stream into Word document.
                        using (WordDocument revisedDocument = new WordDocument(revisedDocumentStreamPath, FormatType.Docx))
                        {
                            //Sets the Comparison option detect format changes, whether to detect format changes while comparing two Word documents.
                            ComparisonOptions compareOptions = new ComparisonOptions();
                            compareOptions.DetectFormatChanges = false;

                            //Compares the original document with revised document.
                            originalDocument.Compare(revisedDocument, "Nancy Davolio", DateTime.Now.AddDays(-1), compareOptions);

                            //Save the Word document.
                            using (FileStream fileStreamOutput = File.Create(Path.GetFullPath("Output/Output.docx")))
                            {
                                originalDocument.Save(fileStreamOutput, FormatType.Docx);
                            }
                        }
                    }                  
                }
            }
        }
    }
}
