# LdapForNet Test

This repo is created to demonstrate an issue we are having with the LdapForNet project.

See the below commands to replicate the issue.

```
# Build the docker image
docker build . -t ldaptest:latest 

# Run the app
docker run -it ldaptest
```
