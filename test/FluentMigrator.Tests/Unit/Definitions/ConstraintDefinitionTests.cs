#region License
// Copyright (c) 2007-2018, FluentMigrator Project
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
// http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
#endregion

using FluentMigrator.Model;

using NUnit.Framework;

namespace FluentMigrator.Tests.Unit.Definitions
{
    [TestFixture]
    public class ConstraintDefinitionTests
    {
        [Test]
        public void WhenDefaultSchemaConventionIsAppliedAndSchemaIsNotSetThenSchemaShouldBeNull()
        {
            var constraintDefinition = new ConstraintDefinition(ConstraintType.PrimaryKey) { ConstraintName = "Test" };

            constraintDefinition.ApplyConventions(new MigrationConventions());

            Assert.That(constraintDefinition.SchemaName, Is.Null);
        }

        [Test]
        public void WhenDefaultSchemaConventionIsAppliedAndSchemaIsSetThenSchemaShouldNotBeChanged()
        {
            var constraintDefinition = new ConstraintDefinition(ConstraintType.PrimaryKey) { ConstraintName = "Test", SchemaName = "testschema" };

            constraintDefinition.ApplyConventions(new MigrationConventions());

            Assert.That(constraintDefinition.SchemaName, Is.EqualTo("testschema"));
        }

        [Test]
        public void WhenDefaultSchemaConventionIsChangedAndSchemaIsNotSetThenSetSchema()
        {
            var constraintDefinition = new ConstraintDefinition(ConstraintType.PrimaryKey) { ConstraintName = "Test" };
            var migrationConventions = new MigrationConventions { GetDefaultSchema = () => "testdefault" };

            constraintDefinition.ApplyConventions(migrationConventions);

            Assert.That(constraintDefinition.SchemaName, Is.EqualTo("testdefault"));
        }
    }
}