using Microsoft.AspNetCore.Mvc;

namespace Study.Controllers
{
    public class Import : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //[HttpGet]
        //[Route("[action]")]
        //public ActionResult ImportData()
        //{
        //    var listUsers = new List<Users>();
        //    Users users;

        //    var excelFilePath = System.IO.Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Sample.xlsx");

        //    if (!System.IO.File.Exists(excelFilePath)) return Ok("File excel not found.");

        //    try
        //    {
        //        // Lets open the existing excel file and read through its content. Open the excel using openxml sdk
        //        using (SpreadsheetDocument doc = SpreadsheetDocument.Open(excelFilePath, false))
        //        {
        //            // Create the object for workbook part
        //            WorkbookPart workbookPart = doc.WorkbookPart;
        //            Sheets thesheetcollection = workbookPart.Workbook.GetFirstChild<Sheets>();

        //            // Using for each loop to get the sheet from the sheetcollection
        //            foreach (Sheet thesheet in thesheetcollection)
        //            {
        //                // Statement to get the worksheet object by using the sheet id
        //                Worksheet theWorksheet = ((WorksheetPart)workbookPart.GetPartById(thesheet.Id)).Worksheet;

        //                SheetData thesheetdata = (SheetData)theWorksheet.GetFirstChild<SheetData>();

        //                foreach (Row thecurrentrow in thesheetdata)
        //                {
        //                    if (thecurrentrow.RowIndex == 1)
        //                    {
        //                        continue;
        //                    }

        //                    string[] arr = new string[3];
        //                    var idx = 0;
        //                    foreach (Cell thecurrentcell in thecurrentrow)
        //                    {
        //                        // Statement to take the integer value
        //                        string currentcellvalue = string.Empty;
        //                        if (thecurrentcell.DataType != null)
        //                        {
        //                            if (thecurrentcell.DataType == CellValues.SharedString)
        //                            {
        //                                int id;
        //                                if (Int32.TryParse(thecurrentcell.InnerText, out id))
        //                                {
        //                                    SharedStringItem item = workbookPart.SharedStringTablePart.SharedStringTable.Elements<SharedStringItem>().ElementAt(id);
        //                                    if (item.Text != null)
        //                                    {
        //                                        currentcellvalue = item.Text.Text;
        //                                    }
        //                                    else if (item.InnerText != null)
        //                                    {
        //                                        currentcellvalue = item.InnerText;
        //                                    }
        //                                    else if (item.InnerXml != null)
        //                                    {
        //                                        currentcellvalue = item.InnerXml;
        //                                    }
        //                                }
        //                            }
        //                        }
        //                        else
        //                        {
        //                            currentcellvalue = thecurrentcell.InnerText;
        //                        }
        //                        arr[idx++] = currentcellvalue;
        //                        if (idx == 3)
        //                        {
        //                            users = new Users();
        //                            var canInsert = true;
        //                            try
        //                            {
        //                                users.ColumnIndex = NumberUtil.TryGetInt32(arr[0]);
        //                                users.Name = arr[1];
        //                                users.Salary = arr[2];
        //                            }
        //                            catch (Exception ex)
        //                            {
        //                                canInsert = false;
        //                                Debug.WriteLine(ex.ToString());
        //                            }

        //                            if (canInsert)
        //                            {
        //                                listUsers.Add(users);
        //                                users = null;
        //                            }

        //                            idx = 0;
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine(ex.ToString());
        //    }

        //    var allItems = (from x in listUsers
        //                    where x.ColumnIndex > 0
        //                    select new
        //                    {
        //                        ColumnIndex = x.ColumnIndex,
        //                        Name = x.Name,
        //                        Salary = x.Salary
        //                    }).ToList();

        //    using (var connection = new NpgsqlConnection(_dbContext.Connection.ConnectionString))
        //    {
        //        connection.Open();
        //        using (var transaction = connection.BeginTransaction())
        //        {
        //            try
        //            {
        //                connection.Execute("INSERT INTO public.\"Users\" (\"ColumnIndex\", \"Name\", \"Salary\") VALUES (@ColumnIndex, @Name, @Salary)", allItems, transaction);

        //                transaction.Commit();
        //            }
        //            catch (Exception ex)
        //            {
        //                Debug.WriteLine(ex.ToString());
        //                transaction.Rollback();
        //                throw;
        //            }
        //            finally
        //            {
        //                connection.Close();
        //            }
        //        }
        //    }

        //    var allUsers = _dbContext.Users.ToList();

        //    return Ok(allUsers.Count);
        //}
    }
}
