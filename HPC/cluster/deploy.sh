#!/bin/bash

# Exit on error
set -e

echo "🚀 Starting deployment process..."

# Check if minikube is running
echo "📋 Checking Minikube status..."
if ! minikube status | grep -q "Running"; then
    echo "❌ Minikube is not running. Starting Minikube..."
    minikube start --nodes=3 --cpus=4 --memory=2048 --driver=docker
else
    echo "✅ Minikube is running"
fi

# Pull Docker image from Docker Hub
echo "📥 Pulling Docker image from Docker Hub..."
docker pull theanhhhhh/pneumonia-app:latest

# Load image into Minikube
echo "📦 Loading image into Minikube..."
minikube image load theanhhhhh/pneumonia-app:latest

# Apply Kubernetes deployment
echo "📝 Applying Kubernetes deployment..."
kubectl apply -f pneumonia-deployment.yaml

# Wait for deployment to be ready
echo "⏳ Waiting for deployment to be ready..."
kubectl rollout status deployment/pneumonia-app --timeout=300s

# Check deployment status
echo "🔍 Checking deployment status..."
kubectl get deployments
kubectl get pods
kubectl get services

# Start port forwarding
echo "🔌 Setting up port forwarding..."
echo "✅ Deployment completed! Access the application at:"
minikube service pneumonia-service --url

echo """
📝 Deployment Summary:
- Docker image built and loaded
- Kubernetes deployment applied
- Services are running
- Port forwarding is active

To check logs: kubectl logs <pod_name>
To describe pod: kubectl describe pod <pod_name>
To restart deployment: kubectl rollout restart deployment pneumonia-deployment
""" 