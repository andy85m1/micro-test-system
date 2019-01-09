# Udemy.com : .NET Core Microservices 

# Docker setup
# Setup shared drive
# - Right click docker icon in taskbar and select settings
# - Click Shared Drives
# - Check the drive containing the Actio project
# - Enter the Windows account password when prompted
# - Ensure the checkbox next to the drive letter is checked when complete

# Docker commands
#
# IMPORTANT: Run Powershell as Admin
#
# To build the api and service images
# cd to C:\Users\jspar\source\repos\GitHub\micro-test-system\sandBoxes\JS>
# Docker build -f Dockerfile-api -t actio.api .
# Docker build -f Dockerfile-activities - t actio.services.activities .
# Docker build -f Dockerfile-identity - t actio.services.identity .


# To run the container
# cd to C:\Users\jspar\source\repos\GitHub\micro-test-system\sandBoxes\JS>
# Docker-compose up

# Docker-compose down
