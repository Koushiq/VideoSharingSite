pipeline {
    agent any

    environment {
        DOTNET_CMD = 'dotnet'
        PUBLISH_PATH = '/publish'
        ZIP_FILE_NAME = 'published-app.zip'
        DEPLOY_PATH = '/var/www/dotnetapp'
        NGINX_CONFIG_PATH = '/etc/nginx/sites-available'
    }

    stages {
        stage('Checkout') {
            steps {
                checkout scm
            }
        }

        stage('Build') {
            steps {
                script {
                    def dotnetCmd = tool name: 'dotnet', type: 'hudson.plugins.dotnet.DotNetToolInstallation'
                    bat "${dotnetCmd} build"
                }
            }
        }

        stage('Publish') {
            steps {
                script {
                    def dotnetCmd = tool name: 'dotnet', type: 'hudson.plugins.dotnet.DotNetToolInstallation'
                    bat "${dotnetCmd} publish -c Release -o ${PUBLISH_PATH}"
                }
            }
        }

        stage('Zip') {
            steps {
                script {
                    // Zip the published files
                    zip zipFile: "${ZIP_FILE_NAME}", archive: false, dir: "${PUBLISH_PATH}"
                }
            }
        }

        stage('Deploy') {
            agent {
                label 'rppi-agent' // Replace with the label of your Linux agent
            }
            steps {
                script {
                    // Create deployment directory if not present
                    sh "mkdir -p ${DEPLOY_PATH}"

                    // Download and extract the zip file
                    sh "curl -o ${DEPLOY_PATH}/${ZIP_FILE_NAME} ${env.WORKSPACE}/${ZIP_FILE_NAME}"
                    sh "unzip -o ${DEPLOY_PATH}/${ZIP_FILE_NAME} -d ${DEPLOY_PATH}"

                    // Create Nginx config if not present
                    sh "[ -e ${NGINX_CONFIG_PATH}/dotnetapp ] || echo 'server { listen 80; server_name localhost; location / { proxy_pass http://localhost:5000; proxy_http_version 1.1; proxy_set_header Upgrade $http_upgrade; proxy_set_header Connection keep-alive; proxy_set_header Host $host; proxy_cache_bypass $http_upgrade; } }' > ${NGINX_CONFIG_PATH}/dotnetapp"
                    
                    // Reload Nginx
                    sh "sudo systemctl reload nginx"
                }
            }
        }
    }

    post {
        always {
            // Clean up or post-build tasks can be added here
        }
    }
}
