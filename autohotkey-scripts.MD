# open terminal
```
^q:: {
    windows := WinGetList("ahk_exe windowsterminal.exe")
    if (windows.Length > 0) {
        WinActivate windows[1]
    } else {
        Run "wt.exe"
    }
}
```

# open vs code
```
global vscodeWindows := []
global vscodeIndex := 0

^w:: {
    global vscodeWindows, vscodeIndex

    ; Rebuild list if empty or any window handle is invalid
    if vscodeWindows.Length = 0 || !AllWindowsValid(vscodeWindows) {
        vscodeWindows := []
        for hwnd in WinGetList("ahk_exe Code.exe") {
            if WinGetTitle("ahk_id " hwnd) {
                vscodeWindows.Push(hwnd)
            }
        }
        vscodeIndex := 0
    }

    if vscodeWindows.Length = 0 {
        MsgBox "No VS Code windows found."
        return
    }

    vscodeIndex += 1
    if vscodeIndex > vscodeWindows.Length
        vscodeIndex := 1

    WinActivate vscodeWindows[vscodeIndex]
}

AllWindowsValid(list) {
    for hwnd in list {
        if !WinExist("ahk_id " hwnd)
            return false
    }
    return true
}
```

# open browser
```
global chromeWindows := []
global chromeIndex := 0

^e:: {
    global chromeWindows, chromeIndex

    ; If the list is empty or any handle is invalid, rebuild the full list
    if chromeWindows.Length = 0 || !AllWindowsValid(chromeWindows) {
        chromeWindows := []
        for hwnd in WinGetList() {
            try {
                if WinGetProcessName(hwnd) = "chrome.exe" && WinGetTitle("ahk_id " hwnd) {
                    chromeWindows.Push(hwnd)
                }
            }
        }
        chromeIndex := 0  ; reset index only when rebuilding the list
    }

    if chromeWindows.Length = 0 {
        Run '"C:\Program Files\Google\Chrome\Application\chrome.exe"'
        return
    }

    ; Move to the next window
    chromeIndex += 1
    if chromeIndex > chromeWindows.Length
        chromeIndex := 1

    WinActivate chromeWindows[chromeIndex]
}

AllWindowsValid(list) {
    for hwnd in list {
        if !WinExist("ahk_id " hwnd) {
            return false
        }
    }
    return true
}

```

# open notes
```
#Requires AutoHotkey v2.0

^t:: {
    targetFolder := "Notes"
    foundHwnd := ""

    for hwnd in WinGetList("ahk_exe Code.exe") {
        title := WinGetTitle(hwnd)
        parts := StrSplit(title, " - ")

        ; Usually, the folder name is the **second last** part before "Visual Studio Code"
        ; So if title is "file - folder - Visual Studio Code", folder is parts[2]
        ; Adjust if title structure varies

        folderName := ""
        if parts.Length >= 2
            folderName := parts[parts.Length - 1]  ; second last part
        else if parts.Length = 1
            folderName := parts[1]

        if folderName && InStr(folderName, targetFolder, false) {
            foundHwnd := hwnd
            break
        }
    }

    if foundHwnd
        WinActivate foundHwnd
    else
        MsgBox("No VS Code window found with folder '" targetFolder "'")
}
```

# test what autohotkey sees
```
^t:: {
    for hwnd in WinGetList("ahk_exe Code.exe") {
        title := WinGetTitle(hwnd)
        MsgBox("HWND: " hwnd "`nTitle: " title)
    }
}

```