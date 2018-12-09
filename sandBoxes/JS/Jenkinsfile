node('win_node_01'){
     try {
        stage('Notify Build Start'){
             notifyBuild('STARTED')
        
        }
    
        stage ('Nuget Restore'){
            dir('sandBoxes/JS/') {
    		    bat "\"${env.nuget}\" restore Actio.sln"
            }
        }
        
        
        stage('Build'){
            dir('sandBoxes/JS/'){
                bat "\"${tool name: 'MSBUILD', type: 'msbuild'}\" /t:Restore /t:Rebuild Actio.sln"
            }
        }

	stage('Run Static Analysis'){

	}

	stage('SonarQube analysis') {
	    dir('sandBoxes/JS/'){                         
                def sqScannerMsBuildHome = tool 'Sonar_scanner_dotnet_core'
                withSonarQubeEnv('sonarQube') {
                    bat "${sqScannerMsBuildHome}\\SonarScanner.MSBuild.exe begin /k:bedford /d:sonar.host.url=http://localhost:9000 /d:sonar.login=44aca34ca70e74dd096680f9a53c992ca7b36e74"
                    echo "building"; 
		    bat "\"${tool name: 'MSBUILD', type: 'msbuild'}\" /t:Restore /t:Rebuild Actio.sln"
                    bat "${sqScannerMsBuildHome}\\SonarScanner.MSBuild.exe end /d:sonar.login=44aca34ca70e74dd096680f9a53c992ca7b36e74"
                }
            } 	
        }
    
     } catch (e) {
    // If there was an exception thrown, the build failed
    currentBuild.result = "FAILED"
    throw e
  } finally {
    // Success or failure, always send notifications
    notifyBuild(currentBuild.result)
  }
}

def notifyBuild(String buildStatus = 'STARTED') {
  // build status of null means successful
  buildStatus =  buildStatus ?: 'SUCCESSFUL'

  // Default values
  def colorName = 'RED'
  def colorCode = '#FF0000'
  def subject = "${buildStatus}: Job '${env.JOB_NAME} [${env.BUILD_NUMBER}]'"
  def summary = "${subject} (${env.BUILD_URL})"
  def details = """<p>STARTED: Job '${env.JOB_NAME} [${env.BUILD_NUMBER}]':</p>
    <p>Check console output at &QUOT;<a href='${env.BUILD_URL}'>${env.JOB_NAME} [${env.BUILD_NUMBER}]</a>&QUOT;</p>"""

  // Override default values based on build status
  if (buildStatus == 'STARTED') {
    color = 'YELLOW'
    colorCode = '#FFFF00'
  } else if (buildStatus == 'SUCCESSFUL') {
    color = 'GREEN'
    colorCode = '#00FF00'
  } else {
    color = 'RED'
    colorCode = '#FF0000'
  }

  // Send notifications
  //slackSend (color: colorCode, message: summary)
  slackSend baseUrl: 'https://micro-test-service.slack.com/services/hooks/jenkins-ci/', channel: '#builds', color: colorCode, message: summary, teamDomain: 'https://micro-test-service.slack.com', token: 'RDKD0Z0z53yIVgCmyRtqgv9t'

  emailext(
      subject: subject,
      body: details,
      recipientProviders: [[$class: 'DevelopersRecipientProvider']]
    )
}
