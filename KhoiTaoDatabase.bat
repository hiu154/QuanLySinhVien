@echo off
chcp 65001 >nul
title KHỞI TẠO CƠ SỞ DỮ LIỆU - QUẢN LÝ SINH VIÊN
color 0b

echo ======================================================================
echo    HỆ THỐNG QUẢN LÝ SINH VIÊN - TỰ ĐỘNG KHỞI TẠO CƠ SỞ DỮ LIỆU
echo ======================================================================
echo.
echo [1/3] Đang tìm kiếm file kịch bản SQL '01_CreateDatabase_QLSV.sql'...

set SQL_FILE=""
if exist "SQL\01_CreateDatabase_QLSV.sql" set SQL_FILE="SQL\01_CreateDatabase_QLSV.sql"
if exist "QuanLySinhVien\SQL\01_CreateDatabase_QLSV.sql" set SQL_FILE="QuanLySinhVien\SQL\01_CreateDatabase_QLSV.sql"
if exist "..\SQL\01_CreateDatabase_QLSV.sql" set SQL_FILE="..\SQL\01_CreateDatabase_QLSV.sql"

if %SQL_FILE%=="" (
    echo [LỖI] Không tìm thấy file '01_CreateDatabase_QLSV.sql'!
    echo Vui lòng đảm bảo thư mục chứa file SQL tồn tại.
    echo.
    pause
    exit /b 1
)

echo [+] Đã tìm thấy: %SQL_FILE%
echo.
echo [2/3] Đang tự động quét và kết nối máy chủ SQL Server cục bộ...

powershell -NoProfile -ExecutionPolicy Bypass -Command ^
    "$sqlPath = Resolve-Path %SQL_FILE%;" ^
    "$sqlContent = [System.IO.File]::ReadAllText($sqlPath, [System.Text.Encoding]::UTF8);" ^
    "$candidates = @('.', 'localhost', '(local)', '.\SQLEXPRESS', '(localdb)\MSSQLLocalDB', '.\MSSQLSERVER01');" ^
    "$found = $false;" ^
    "foreach ($srv in $candidates) {" ^
    "    try {" ^
    "        $cs = \"Server=$srv;Database=master;Integrated Security=True;TrustServerCertificate=True;Connect Timeout=3;\";" ^
    "        $conn = New-Object System.Data.SqlClient.SqlConnection($cs);" ^
    "        $conn.Open();" ^
    "        Write-Host \"[+] Ket noi thanh cong toi may chu: $srv\" -ForegroundColor Green;" ^
    "        $batches = [System.Text.RegularExpressions.Regex]::Split($sqlContent, '^\s*GO\s*$', [System.Text.RegularExpressions.RegexOptions]::Multiline -bor [System.Text.RegularExpressions.RegexOptions]::IgnoreCase);" ^
    "        Write-Host \"[+] Dang thuc thi cac khoi lenh tao 9 bang va du lieu mau...\" -ForegroundColor Yellow;" ^
    "        $count = 0;" ^
    "        foreach ($b in $batches) {" ^
    "            $t = $b.Trim();" ^
    "            if ($t.Length -gt 0) {" ^
    "                $cmd = $conn.CreateCommand();" ^
    "                $cmd.CommandText = $t;" ^
    "                $cmd.CommandTimeout = 120;" ^
    "                [void]$cmd.ExecuteNonQuery();" ^
    "                $count++;" ^
    "            }" ^
    "        }" ^
    "        $conn.Close();" ^
    "        $found = $true;" ^
    "        Write-Host \"`n[THANH CONG] Da tao xong CSDL 'QuanLySinhVienDB' tren may chu $srv ($count khoi lenh)!\" -ForegroundColor Cyan;" ^
    "        break;" ^
    "    } catch {" ^
    "    }" ^
    "}" ^
    "if (-not $found) {" ^
    "    Write-Host \"`n[CANH BAO] Khong the tu dong ket noi may chu SQL Server qua Windows Authentication.\" -ForegroundColor Red;" ^
    "    Write-Host \"Ban co the mo ung dung va su dung nut 'Cau hinh CSDL' tren man hinh dang nhap.\" -ForegroundColor Yellow;" ^
    "    exit 2;" ^
    "}"

if %ERRORLEVEL% equ 0 (
    echo.
    echo ======================================================================
    echo [3/3] HOÀN TẤT KHỞI TẠO CSDL THÀNH CÔNG!
    echo ======================================================================
    echo  Tai khoan thu nghiem mac dinh:
    echo    * Quan tri vien : admin      / 123456
    echo    * Giang vien    : giangvien1 / 123456
    echo    * Sinh vien     : sv001      / 123456
    echo ======================================================================
    echo.
) else (
    echo.
    echo [!] Khong the khoi tao qua tap lenh nay. Ban hay khoi chay truc tiep ung dung!
)

pause
