using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CommandHandler {

    private readonly Dictionary<string, Command> commands = new Dictionary<string, Command>();

    public CommandHandler() {
        RegisterCommand("print", PrintHandler, new List<Argument> {
            new StringArgument("msg")
        }, "Prints a message into the console.");
        RegisterCommand("conv", ConvertHandler, new List<Argument> {
            new FloatArgument("value")
        }, "Prints a decimal number into the console.");
    }

    public string[] ParseCommand(string input) {
        return input.Split(' ');
    }

    public void RegisterCommand(string name, CommandExecutor executor, List<Argument> args,
        string helpText) {
        var command = new Command(name, executor, args, helpText);
        commands[name] = command;
    }

    public void ExecuteCommand(string[] cmd) {
        Command command;
        try {
            command = commands[cmd[0]];
        }
        catch {
            Debug.Log($"Command {cmd[0]} was not found!");
            return;
        }

        command.Execute(cmd.Skip(1).ToArray());
    }

    // PrintHandler methods
    private static void PrintHandler(string[] args) {
        // TODO actually print in the console lmao
        Debug.Log(args[0]);
    }

    private void ConvertHandler(string[] args) {
        Debug.Log(args[0]);
    }
}

public class Command {
    public string name;
    public CommandExecutor executor;
    public List<Argument> args;
    public string helpText;

    public Command(string name, CommandExecutor executor, List<Argument> args, string helpText) {
        this.name = name;
        this.executor = executor;
        this.args = args;
        this.helpText = helpText;
    }

    public void Execute(string[] args) {
        // TODO type validation
        for (int i = 0; i < this.args.Count; i++) {
            try {
                args[i] = this.args[i].Convert(args[i]).ToString();
            }
            catch (Exception e) {
                // fuckup
                Debug.Log(
                    $"Could not cast parameter {this.args[i].argName} to {this.args[i].argType}! (value: {args[i]})");
            }
        }

        executor.Invoke(args);
    }
}

public abstract class Argument {

    public string argName { get; set; }

    public virtual Type argType { get; }

    public abstract object Convert(string value);
    
    public Argument(string argName) {
        this.argName = argName;
    }
}

public class StringArgument : Argument {

    public override Type argType { get; } = typeof(string);

    public override object Convert(string value) {
        return value; // do nothing
    }

    public StringArgument(string argName) : base(argName) {
        
    }
}

public class IntArgument : Argument {

    public override Type argType { get; } = typeof(int);

    public override object Convert(string value) {
        return System.Convert.ToInt32(value);
    }

    public IntArgument(string argName) : base(argName) {
        
    }
}

public class FloatArgument : Argument {
    
    public override Type argType { get; } = typeof(double);

    public override object Convert(string value) {
        return System.Convert.ToDouble(value);
    }

    public FloatArgument(string argName) : base(argName) {
        
    }
}

public delegate void CommandExecutor(string[] args);