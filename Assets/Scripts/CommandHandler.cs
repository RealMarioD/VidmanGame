using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CommandHandler {

    private readonly Dictionary<string, Command> commands = new Dictionary<string, Command>();

    public CommandHandler() {
        RegisterCommand("print", PrintHandler, new[] {typeof(string)}, new[] {"msg"},
            "Prints a message into the console.");
    }

    public string[] ParseCommand(string input) {
        return input.Split(' ');
    }

    public void RegisterCommand(string name, CommandExecutor executor, Type[] args, string[] argNames,
        string helpText) {
        var command = new Command(name, executor, args, argNames, helpText);
        commands[name] = command;
    }

    public void ExecuteCommand(string[] cmd) {
        var command = commands[cmd[0]];
        command.Execute(cmd.Skip(1).ToArray());
    }

    // PrintHandler methods
    private void PrintHandler(string[] args) {
        // TODO actually print in the console lmao
        Debug.Log(args[0]);
    }
}

public class Command {
    public string name;
    public CommandExecutor executor;
    public Type[] args;
    public string[] argNames;
    public string helpText;

    public Command(string name, CommandExecutor executor, Type[] args, string[] argNames, string helpText) {
        this.name = name;
        this.executor = executor;
        this.args = args;
        this.argNames = argNames;
        this.helpText = helpText;
    }

    public void Execute(string[] args) {
        // TODO type validation
        executor.Invoke(args);
    }
}

public delegate void CommandExecutor(string[] args);