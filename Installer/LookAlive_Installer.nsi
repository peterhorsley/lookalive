;NSIS Modern User Interface
;Zorn Software Look Alive Installer
;Written by Peter Horsley

;--------------------------------
;Include Modern UI

  !include "MUI.nsh"

;--------------------------------
;General

  ;Name and file
  Name "Look Alive v1.24"
  OutFile "LookAlive_v1.24_Setup.exe"

  ;Default installation folder
  InstallDir "$PROGRAMFILES\Zorn Software\Look Alive v1.24"

  ;Start Menu Folder Page Configuration
  !define MUI_STARTMENUPAGE_REGISTRY_ROOT "HKLM" 
  !define MUI_STARTMENUPAGE_REGISTRY_KEY "Software\Zorn Software\Look Alive\1.24" 
  !define MUI_STARTMENUPAGE_REGISTRY_VALUENAME "Start Menu Folder"
  !define MUI_STARTMENUPAGE_DEFAULTFOLDER "Zorn Software\Look Alive v1.24"
  !define MUI_STARTMENUPAGE_NODISABLE

  ;Vista redirects $SMPROGRAMS to all users without this
  RequestExecutionLevel admin

;--------------------------------
;Variables

  Var MUI_TEMP
  Var STARTMENU_FOLDER

;--------------------------------
;Interface Settings

  BrandingText "Look Alive - Montior your connection to a remote computer"

  ; Modern parameters
  !define MUI_ICON "resources\orange-install.ico"
  !define MUI_UNICON "resources\orange-uninstall.ico"
  !define MUI_WELCOMEFINISHPAGE_BITMAP "resources\orange.bmp"
  !define MUI_UNWELCOMEFINISHPAGE_BITMAP "resources\orange-uninstall.bmp"
  !define MUI_HEADERIMAGE
  !define MUI_HEADERIMAGE_BITMAP "resources\LookAlive.bmp"
  !define MUI_HEADERIMAGE_RIGHT
  !define MUI_FINISHPAGE_RUN "$INSTDIR\LookAlive.exe"
  !define MUI_FINISHPAGE_RUN_TEXT "Run LookAlive v1.24 now."
  !define MUI_ABORTWARNING

;--------------------------------
;Pages

  !insertmacro MUI_PAGE_WELCOME
  !insertmacro MUI_PAGE_LICENSE "gpl.txt"
  !insertmacro MUI_PAGE_DIRECTORY
  !insertmacro MUI_PAGE_STARTMENU Application $STARTMENU_FOLDER
  !insertmacro MUI_PAGE_INSTFILES
  !insertmacro MUI_PAGE_FINISH

  !insertmacro MUI_UNPAGE_WELCOME
  !insertmacro MUI_UNPAGE_CONFIRM
  !insertmacro MUI_UNPAGE_INSTFILES
  !insertmacro MUI_UNPAGE_FINISH

;--------------------------------
;Languages

  !insertmacro MUI_LANGUAGE "English"

;--------------------------------
;Installer Sections

Section "" ;No components page, name is not important

  SetOutPath "$INSTDIR"

  File ..\LookAlive\bin\Release\LookAlive.exe

  ;Store installation folder
  WriteRegStr HKLM "Software\Zorn Software\Look Alive\1.24" "" $INSTDIR

  ;Create uninstaller
  WriteUninstaller "$INSTDIR\Uninstall.exe"

  !insertmacro MUI_STARTMENU_WRITE_BEGIN Application
    
    ;Create shortcuts
    CreateDirectory "$SMPROGRAMS\$STARTMENU_FOLDER"
    CreateShortCut "$SMPROGRAMS\$STARTMENU_FOLDER\Look Alive.lnk" "$INSTDIR\LookAlive.exe"
    CreateShortCut "$SMPROGRAMS\$STARTMENU_FOLDER\Uninstall.lnk" "$INSTDIR\Uninstall.exe"
  
  !insertmacro MUI_STARTMENU_WRITE_END

  ;Update ARP
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\Look Alive v1.24" \
                   "DisplayName" "Look Alive v1.24"
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\Look Alive v1.24" \
                   "UninstallString" "$INSTDIR\uninstall.exe"
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\Look Alive v1.24" \
                   "Publisher" "Zorn Software"
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\Look Alive v1.24" \
                   "DisplayIcon" "$INSTDIR\LookAlive.exe"

SectionEnd

;--------------------------------
;Uninstaller Section

Section "Uninstall"

  ; Note: Don't use RMDir /r "$INSTDIR" as this is unsafe depending on where the user installs!

  Delete "$INSTDIR\LookAlive.exe"
  Delete "$INSTDIR\Uninstall.exe"
  RMDir "$INSTDIR"

  !insertmacro MUI_STARTMENU_GETFOLDER Application $MUI_TEMP
    
  Delete "$SMPROGRAMS\$MUI_TEMP\Look Alive.lnk"
  Delete "$SMPROGRAMS\$MUI_TEMP\Uninstall.lnk"
  
  ;Delete empty start menu parent diretories
  StrCpy $MUI_TEMP "$SMPROGRAMS\$MUI_TEMP"
 
  startMenuDeleteLoop:
	ClearErrors
    RMDir $MUI_TEMP
    GetFullPathName $MUI_TEMP "$MUI_TEMP\.."
    
    IfErrors startMenuDeleteLoopDone
  
    StrCmp $MUI_TEMP $SMPROGRAMS startMenuDeleteLoopDone startMenuDeleteLoop
  startMenuDeleteLoopDone:

  DeleteRegKey /ifempty HKLM "Software\Zorn Software\Look Alive\1.24"

  ;Update ARP
  DeleteRegKey HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\Look Alive v1.24"

SectionEnd
