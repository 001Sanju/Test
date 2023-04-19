<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LabourCategoryDetails.aspx.cs" Inherits="TestApp.ImportLabourDetails.LabourCategoryDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
         <div>
            <div class="col-sm-3">
                <div class="form-group">
                   <asp:Label ID="lbsmsg" runat="server" ForeColor="red" ></asp:Label>
                </div>
            </div>
            <div class="col-sm-3">
                <div class="form-group">
                    <label>
                        Browse Excel File</label>
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </div>
            </div>
            <div class="col-sm-2 ptop">
                <div class="form-group">
                    <asp:Button ID="BtnUpload" runat="server" CssClass="btn btn-primary btn-xs" Text="Upload"
                        OnClick="BtnUpload_Click" />
                </div>
            </div>
            <br />
            <div class="col-sm-2 pull-right">
                <div class="form-group">
                    <asp:Button ID="btnSampleExcel" runat="server" Text="Sample Excel" OnClick="btnSampleExcel_Click" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
