# Automating `brew update && brew upgrade && brew cleaup`

### 1. Create a shell script for Homebrew management:

```bash
#!/bin/zsh

if /opt/homebrew/bin/brew update && /opt/homebrew/bin/brew upgrade && /opt/homebrew/bin/brew cleanup; then
    osascript -e 'display notification "Homebrew update and upgrade completed successfully." with title "Homebrew Updater"'
else
    osascript -e 'display notification "Homebrew update or upgrade failed. Check logs for details." with title "Homebrew Updater"'
fi
```

**Note**: The Homebrew binary is stored at `/opt/homebrew/bin/brew` on Apple Silicon-based Macs. If you are running the script on an Intel-based Mac, replace the path to Homebrew with `/usr/local/bin/brew`. If you want to check where Homebrew is installed on your system, run the command:

```bash
which brew
```

The file can be saved wherever works for you. I keep mine as `~/.brew_update.sh` so it doesn't clutter the visible files in the home directory.

### 2. Make the script executable:

```bash
chmod +x ~/.brew_update.sh
```

Replace `~/.brew_update.sh` with the path to your script.

### 3. Create an Automator job to run the script:

Open **Automator**:

* Click "New Document".

* Select "Application" and click "Choose".

* From the list of actions, drag "Run Shell Script" to the main workflow area.

* Add the following line to run the script (replace this with the path to your script):

  ```bash
  ~/brew_update.sh
  ```

* Save the workflow in `~/Applications`.

  You can save the workflow in whatever location works for you. I am choosing to use this location so that it is easy to find and accessible from Launchpad, while being separate from the main applications in `/Applications`/

### 4. Automate the application to run on login:

* Go to **System Settings > Login Items & Extensions**.
* At your workflow to the **Open at Login** list.