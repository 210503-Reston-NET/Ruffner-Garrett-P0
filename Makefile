.PHONY: build run clean test

#solution_root is the directory containing the root .sln file
solution_root = App

#solution_main is the directory containing the project with a main method. Relative to solution_root.
solution_main = UI

#log_dir is the name of directory with logs relative to solution_root
log_dir = logs

build:
	dotnet build $(solution_root)
run: 
	dotnet run --project $(solution_root)/$(solution_main)
test:
	dotnet test $(solution_root)
clean: clearlogs
	dotnet clean $(solution_root)
clearlogs:
	rm -f $(solution_root)/$(log_dir)/*
