docker run -d -p 5432:5432 -it --rm -v ${PWD}/data:/var/lib/postgresql/data -e POSTGRES_PASSWORD=pwd postgres